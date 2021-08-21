#!/bin/bash
set -e # Exit with nonzero exit code if anything fails

SOURCE_BRANCH="master"
TARGET_BRANCH="gh-pages"

# Save some useful information
SHA=`git rev-parse --verify HEAD`
COMMIT_AUTHOR_EMAIL="konard@me.com"

# DocFX installation
nuget install docfx.console
mono $(ls | grep "docfx.console.")/tools/docfx.exe docfx.json

# Clone the existing gh-pages for this repo into out/
# Create a new empty branch if gh-pages doesn't exist yet (should only happen on first deply)
git clone https://github.com/LinksPlatform/Documentation out
cd out
git checkout $TARGET_BRANCH || git checkout --orphan $TARGET_BRANCH
cd ..

# Clean out existing contents
rm -rf out/**/* || exit 0

# Copy genereted docs site
cp -r doc/generated/site/* out

# Now let's go have some fun with the cloned repo
cd out
git config user.name "GitHub Actions"
git config user.email "$COMMIT_AUTHOR_EMAIL"
git remote rm origin
git remote add origin https://linksplatform-docs:$TOKEN@github.com/LinksPlatform/Documentation.git

# Commit the "changes", i.e. the new version.
# The delta will show diffs between new and old versions.
git add -A .
git commit -m "Deploy to GitHub Pages: ${SHA}"

# Now that we're all set up, we can push.
git push https://linksplatform-docs:$TOKEN@github.com/LinksPlatform/Documentation.git $TARGET_BRANCH
