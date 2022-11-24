// noinspection JSUnresolvedVariable

function InitEditor() {
    ClassicEditor
        .create(document.querySelector('#editor'))
        .then(r => {
            window.editor = r
        })
        .catch(error => {
            console.error(error);
        });
}

function GetEditorData() {
    return window.editor.getData()
}