#!/bin/sh

if test "$#" -ne 1; then
    echo "bad number of arguments. I got $# arguments.";
    echo "usage: run.sh <image_id>";
else
    echo "running image $1"
    docker run -it $1
fi