import sys
import getopt

# Variables
# Build Number | ${{ github.run_number }} | --build-number

build_number = 0

# Commit | ${{ github.sha }} | --commit
commit = ""

# Commit Message | ${{ github.event.head_commit.message }} | --commit-message
commit_message = ""

# Commit Author | ${{ github.event.head_commit.author.name }} | --commit-author
commit_author = ""


def extract_value(argv, arg):
    index = argv.index(arg) + 1

    variable = argv[index]

    index += 1

    if index >= len(argv):
        return variable

    while argv[index][0] != "-":
        variable += ' ' + argv[index]
        index += 1
        if index >= len(argv):
            break

    return variable


def get_variables(argv):
    global build_number, commit, commit_message, commit_author

    # Parse command line arguments

    for arg in argv:
        if arg == "--build-number":
            build_number = extract_value(argv, arg)
        elif arg == "--commit":
            commit = extract_value(argv, arg)
        elif arg == "--commit-message":
            commit_message = extract_value(argv, arg)
        elif arg == "--commit-author":
            commit_author = extract_value(argv, arg)

    # Print variables

def write_to_changelog():
    global build_number, commit, commit_message, commit_author

    # Write to changelog
    # open("CHANGELOG.md", "x")
    
    with open("CHANGELOG.md", "a") as changelog:
        changelog.write("## Build " + build_number + "\n")
        changelog.write("Commit: " + commit + "\n")
        changelog.write("Commit Message: " + commit_message + "\n")
        changelog.write("Commit Author: " + commit_author + "\n")
        changelog.write("\n")
        
    
        
        

if __name__ == "__main__":

    get_variables(sys.argv)

    print("Build Number:", build_number)
    print("Commit:", commit)
    print("Commit Message:", commit_message)
    print("Commit Author:", commit_author)
    
    write_to_changelog()
