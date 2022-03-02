async function SaveFile(fileName, content) {
    //const arrayBuffer = await contentStreamReference.arrayBuffer();
    //var decodedData = atob(content);
    //console.log(content);
    //console.log(decodedData);
    const arrayBuffer = await content.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);
    console.log(content);
    console.log(blob);
    console.log(url);
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