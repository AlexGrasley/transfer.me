function SaveFile(FileName, Content) {
    var link = document.createElement('a');
    link.download = FileName;
    link.href = "data:text/plain;charset=utf-8," + encodeURIComponent(Content)
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}
//method takes file namr and filestream ref for parameters
/*
 (Line: 2) Reading the files stream reference as the buffer.
(Line: 3)  Initialized the 'Blob' that helps to read the file data.
(Line: 5) Creating the file URL with the help of 'URL.createObjectURL()'.
(Line: 12-22) The 'triggerFileDownload()' method contains logic to create a dynamic anchor tag and to that anchor tag our file stream URL passed as src value and then calls the anchor tag download and then calls click event of anchor tag to download file and then remove the dynamically created anchor tag.
(Line: 9) After file download relieve the URL resources by calling the 'revokeObjectURL()' method.
 */
async function downloadFileFromStream(fileName, contentStreamReference) {
    const arrayBuffer = await contentStreamReference.arrayBuffer();
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