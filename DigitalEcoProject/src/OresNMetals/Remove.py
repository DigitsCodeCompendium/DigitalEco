import os

# Path to the text file containing the list of files to delete
file_list_path = 'Readme.txt'

# Read the file paths from the text file
with open(file_list_path, 'r') as file:
    files_to_delete = file.readlines()

# Delete the files, ignoring comment lines
for file_path in files_to_delete:
    file_path = file_path.strip()
    
    # Skip lines that are comments or empty
    if file_path.startswith('//') or not file_path:
        continue
    
    try:
        os.remove(file_path)
        print(f"Deleted: {file_path}")
    except FileNotFoundError:
        print(f"File not found: {file_path}")
    except Exception as e:
        print(f"Error deleting {file_path}: {e}")

input('press enter to close')   