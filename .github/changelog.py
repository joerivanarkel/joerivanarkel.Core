import sys
import getopt
import os
import json

def get_env_variables():
    payload = os.environ.get('GITHUB_EVENT_PATH')
    with open(payload, 'r') as f:
        event_data = json.load(f)
        
        return event_data


def write_to_changelog(event_data):
    new_line = "<br>\n"
    try:
        build_number = sys.argv[1]
    except:
        build_number = "0"
    
    with open("doc/CHANGELOG.md", "a") as changelog:
        changelog.write("## Build " + build_number + new_line)
        changelog.write("Sender: " + event_data["sender"]["login"] + new_line)
        changelog.write("Branch: " + event_data["ref"].replace("refs/heads/", "") + new_line)
        changelog.write(new_line)
        
        for commit in event_data["commits"]:
            changelog.write("### Commit: " + commit["message"] + new_line)
            changelog.write("Commit Id: " + commit["id"] + new_line)
            changelog.write("Commit Message: " + commit["message"] + new_line)
            changelog.write("Commit Author: " + commit["author"]["name"] + new_line)
            changelog.write("Timestamp: " + commit["timestamp"] + new_line)
            changelog.write(new_line)
        
        

if __name__ == "__main__":
    event_data = get_env_variables()

    write_to_changelog(event_data)
    
