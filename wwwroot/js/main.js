// noinspection JSUnresolvedVariable

function InitEditor() {
    BalloonEditor
        .create(document.querySelector('#editor'), {
        })
        .then(editor => {
            window.editor = editor;
        })
        .catch(err => {
            console.error(err.stack);
        });
}

function GetEditorData() {
    return window.editor.getData()
}

function SetEditorData(content) {
    editor.setData(content)
}

function InitHighlight() {
    hljs.highlightAll();
}