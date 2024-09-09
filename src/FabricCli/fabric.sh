#!/bin/bash

# Ensure that at least one argument is passed
if [ "$#" -lt 1 ]; then
    echo "Usage: $0 <command> [arguments...]"
    exit 1
fi

# Get environment variables from the system
AZURE_TENANT_ID=${AZURE_TENANT_ID}
AZURE_CLIENT_ID=${AZURE_CLIENT_ID}
AZURE_CLIENT_SECRET=${AZURE_CLIENT_SECRET}


# Run Docker container with environment variables
docker run --rm \
  -e AZURE_TENANT_ID="$AZURE_TENANT_ID" \
  -e AZURE_CLIENT_ID="$AZURE_CLIENT_ID" \
  -e AZURE_CLIENT_SECRET="$AZURE_CLIENT_SECRET" \
  ghcr.io/stevenbuglione/fabric-cli:release "$@"



