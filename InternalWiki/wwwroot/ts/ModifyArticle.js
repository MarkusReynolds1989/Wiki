var ModifyArticle = /** @class */ (function () {
    function ModifyArticle(tiID, conID, butID, tagID, ediID) {
        var _this = this;
        // Return the text of the title.
        this.GetTitle = function () {
            return document.getElementById(_this.titleID).innerHTML;
        };
        // Return the text of the content.
        this.GetContent = function () {
            return document.getElementById(_this.contentID).innerHTML;
        };
        this.GetTags = function () {
            return document.getElementById(_this.contentID).innerHTML;
        };
        this.titleID = tiID;
        this.contentID = conID;
        this.buttonsID = butID;
        this.tagsID = tagID;
        this.editorID = ediID;
    }
    ModifyArticle.prototype.EditArticle = function () {
        this.HideTags();
        this.InsertEditor();
    };
    //Hide all the original elements on the page so we can write over them.
    ModifyArticle.prototype.HideTags = function () {
        var title = document.getElementById(this.titleID);
        var content = document.getElementById(this.contentID);
        var tags = document.getElementById(this.tagsID);
        var button = document.getElementById(this.buttonsID);
        title.style.display = "none";
        content.style.display = "none";
        tags.style.display = "none";
        button.style.display = "none";
    };
    //Insert HTML to represent editor and add the get strings to them.
    ModifyArticle.prototype.InsertEditor = function () {
        var title = this.GetTitle();
        var content = this.GetContent();
        var tags = this.GetTags();
        document.getElementById(this.editorID).innerHTML =
            // TODO: Find out why this is broken. Producing a 400 error. Client side problem.
            "\n<div class=\"text-center\">\n    <h1>Modify Article</h1>\n    <form method=\"post\" class=\"form-group text-left\">\n        <br/>\n        <div class=\"btn-toolbar\" role=\"toolbar\">\n            <div class=\"btn-group\" role=\"group\">\n                <button type=\"button\"\n                    class=\"btn btn-outline-dark\"\n                    name=\"bold\"\n                    onclick=\"insertHTMLCode('b')\">\n                <b> B </b>\n                </button>\n                <button type=\"button\"\n                    class=\"btn btn-outline-dark\"\n                    name=\"italic\"\n                    onclick=\"insertHTMLCode('i')\">\n                <i> I </i>\n                </button>\n                <button\n                    type=\"button\"\n                    class=\"btn btn-outline-dark\"\n                    name=\"code\"\n                    onclick=\"insertHTMLCode('c')\">\n                Code\n                </button>\n            </div>\n        </div>\n        <label for=\"newTitle\">Title:</label>\n        <input type=\"text\" id=\"newTitle\" class=\"form-control\" value = title />\n        <label for=\"newTags\">Tags:</label>\n        <input type=\"text\" id=\"newTags\" class=\"form-control\" value = tags />\n        <label for=\"newContent\">Content:</label>\n        <textarea class=\"form-control\"\n            id=\"newContent\"\n            rows=\"10\"\n            cols=\"80\"> \n        </textarea>\n        <br/>\n        <button type=\"submit\" class=\"btn btn-primary\">Submit</button>\n    </form>\n</div>\n<script>\n    function insertHTMLCode(input) {\n        let content = document.getElementById(\"newContent\");\n        switch(input) {\n            case 'i':\n                content.value += \"<i></i>\";\n                break;\n            case 'b':\n                content.value += \"<b></b>\";\n                break;\n            case 'c':\n                content.value += \"\\n<pre>\\n<code>\\n Insert snippet here\\n</code>\\n</pre>\\n\";\n                break;\n        }\n    }\n</script>\n    ";
        var initContent = document.getElementById("newContent");
        initContent.value += content;
    };
    return ModifyArticle;
}());
//# sourceMappingURL=ModifyArticle.js.map