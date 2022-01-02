# backMeUp
A simple program for Linux that creates backups of selected files/directories when they change.

## Dependencies:
`bash tar inotify-tools`

## Usage:
`./backMeUp directory1 directory2 file1 file2…`

Specified files/directories will be tracked for changes, and when that happens they will be backed up to `workingdirectory/backups/`.

Files just get copied, directories are compessed into `.tar.gz` archives.

All backed up files have their name changed (backup time and date gets prepended before their original name).
