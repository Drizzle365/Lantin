// noinspection JSUnresolvedVariable

function InitEditor() {
    ClassicEditor
        .create(document.querySelector('#editor'))
        .catch(error => {
            console.error(error);
        });
}