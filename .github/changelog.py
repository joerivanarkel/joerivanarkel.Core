import sys
import getopt
import os
import json

# Variables
# Build Number | ${{ github.run_number }} | --build-number

build_number = 0
commits = []
commit_message = []
commit_author = []
time = []
modified_files = []
added_files = []
removed_files = []


def extract_value(argv, arg):
    index = argv.index(arg) + 1
    
    variable = [argv[index]]
    
    index += 1
    
    if index >= len(argv):
        return variable

    while argv[index][0] != "-":
        variable.append(argv[index])
        index += 1
        if index >= len(argv):
            break
        
    return variable

def get_variables(argv):
    global build_number, commit, commit_message, commit_author, time, modified_files, added_files, removed_files

    # Parse command line arguments

    for arg in argv:
        if arg == "--build-number":
            build_number = extract_value(argv, arg)
        elif arg == "--commits":
            commit = extract_value(argv, arg)
        elif arg == "--commit-message":
            commit_message = extract_value(argv, arg)
        elif arg == "--commit-author":
            commit_author = extract_value(argv, arg)
        elif arg == "--time":
            time = extract_value(argv, arg)
        elif arg == "--modified-files":
            modified_files = extract_value(argv, arg)
        elif arg == "--added-files":
            added_files = extract_value(argv, arg)
        elif arg == "--removed-files":
            removed_files = extract_value(argv, arg)
            

    # Print variables

def write_to_changelog():
    global build_number, commit, commit_message, commit_author, time, modified_files, added_files, removed_files

    # Write to changelog
    # open("CHANGELOG.md", "x")
    
    new_line = "<br>\n"
    
    with open("doc/CHANGELOG.md", "a") as changelog:
        changelog.write("## Build " + build_number + new_line)
        changelog.write("Commit: " + commit + new_line)
        changelog.write("Commit Message: " + commit_message + new_line)
        changelog.write("Commit Author: " + commit_author + new_line)
        changelog.write("Modified Files: " + str(modified_files) + new_line)
        changelog.write("Added Files: " + str(added_files) + new_line)
        changelog.write("Removed Files: " + str(removed_files) + new_line)
        changelog.write(new_line)
        
        

if __name__ == "__main__":
    get_env_variables()

    print("Build Number:", build_number)
    print("Commit:", commit)
    print("Commit Message:", commit_message)
    print("Commit Author:", commit_author)
    
    write_to_changelog()
    
