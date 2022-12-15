function InitFancyBox() {
    Fancybox.bind(".mud-markdown-body img", {});
}

function EditorTab() {
    const editor = document.getElementById("editor")
    document.getElementById("editor").onkeydown = (e) => {
        if (e.key === "Tab") {
            e.preventDefault();
            let start = editor.selectionStart;
            let end = editor.selectionEnd;
            editor.value = editor.value.substring(0, start) + "    " + editor.value.substring(end);
            editor.selectionStart = start + 1;
            editor.selectionEnd = start + 1;
        }
    }
}
