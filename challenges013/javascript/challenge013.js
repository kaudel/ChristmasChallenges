function getFilesToBackup(lastBackup, changes) {
    let result = [];
    const modifiedFiles = new Set();

    for (const change of changes) {
        const fileId = change[0];
        const modificationTimestamp = change[1];

        if (modificationTimestamp > lastBackup) {
            modifiedFiles.add(fileId);
        }
    }

    // Convert the Set to an array and sort the IDs in ascending order
    result = Array.from(modifiedFiles).sort((a, b) => a - b);
    return result;
}

let lastBackup = 1546300800

let changes = [
    [ 3, 1546301100 ],
    [ 2, 1546300800 ],
    [ 1, 1546300800 ],
    [ 1, 1546300900 ],
    [ 1, 1546301000 ]
]
console.log(getFilesToBackup(lastBackup, changes));