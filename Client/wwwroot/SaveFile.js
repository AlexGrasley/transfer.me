async function SaveFile(fileName, content) {
    const arrayBuffer = await content.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);
    triggerFileDownload(fileName, url);

    URL.revokeObjectURL(url);
}

function triggerFileDownload(FileName, url) {
    const anchorElement = document.createElement("a");
    anchorElement.href = url;

    if (FileName) {
        anchorElement.download = FileName;
    }

    anchorElement.click();
    anchorElement.remove();
}