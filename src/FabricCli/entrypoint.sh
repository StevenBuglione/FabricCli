#!/bin/sh

# Trim trailing whitespace from the command
CMD="$*"
CMD=$(echo "$CMD" | sed 's/[[:space:]]*$//')

# Execute the trimmed command
exec /app/fabric $CMD
