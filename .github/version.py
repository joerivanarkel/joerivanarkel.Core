import os
import sys
import xml.etree.ElementTree as ET
import json

# 1.0.0.1234-build

branch_name = ""
for arg in sys.argv[1:]:
    branch_name += f"{arg}-"
if branch_name.endswith("-"):
    branch_name = branch_name[:-1]
    
if branch_name.startswith("refs/heads/"):
    branch_name = branch_name.replace("refs/heads/", "")
branch_name.replace("/", "-")

    
if branch_name == "":
    branch_name = "main"

def get_version(components):
    if len(components) == 4: 
        major, minor, patch, build = version_value.split(".")
    elif len(components) == 3:
        major, minor, patch = version_value.split(".")
        build = 0
    elif len(components) == 2:
        major, minor = version_value.split(".")
        patch = 0
        build = 0
    elif len(components) == 1:
        major = version_value
        minor = 0
        patch = 0
        build = 0
    else:
        print("Invalid version format")
        exit(1)
    
    return major, minor, patch, build

def set_output(name, value):
    with open(os.environ['GITHUB_OUTPUT'], 'a') as fh:
        print(f'{name}={value}', file=fh)

def new_version(branch_name, major, minor, patch, build):
    # if build contains a dash, it is a prerelease version
    build = build.split("-")[0]
    
    if branch_name == "main" or branch_name == "master":
        patch = str(int(patch) + 1)
        build = int(build) + 1
        new_version = f"{major}.{minor}.{patch}.{build:04d}"
    else:
        build = int(build) + 1
        new_version = f"{major}.{minor}.{patch}.{build:04d}-{branch_name}"
    
    set_output("build_number", build)
    return new_version


for root, dirs, files in os.walk("."):
    for file in files:
        if file.endswith(".csproj") and not "Test" in file:
            file_path = os.path.join(root, file)
            
            tree = ET.parse(file_path)
            version_element = tree.find(".//Version")
            version_value = version_element.text
            
            print(version_value)
            major, minor, patch, build = get_version(version_value.split("."))
                
            version_element.text = new_version(branch_name, major, minor, patch, build)

            tree.write(file_path)
        else:
            print("Skipping", file)

payload = os.environ.get('GITHUB_EVENT_PATH')
with open(payload, 'r') as f:
    event_data = json.load(f)

# write event_data to file
with open("event_data.json", "w+") as f:
    json.dump(event_data, f, indent=4)
