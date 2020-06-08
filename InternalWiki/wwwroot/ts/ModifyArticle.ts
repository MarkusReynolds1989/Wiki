class ModifyArticle {
    readonly titleID: string;
    readonly contentID: string;
    readonly buttonsID: string;
    readonly tagsID: string;
    //Where to the put the editor.
    readonly editorID: string;

    constructor(tiID: string
        , conID: string
        , butID: string
        , tagID: string
        , ediID: string) {
        this.titleID = tiID;
        this.contentID = conID;
        this.buttonsID = butID;
        this.tagsID = tagID;
        this.editorID = ediID;
    }

    public EditArticle(): void {
        this.HideTags()
        this.InsertEditor();
    }

    //Hide all the original elements on the page so we can write over them.
    private HideTags(): void {
        let title: HTMLElement = document.getElementById(this.titleID);
        let content: HTMLElement = document.getElementById(this.contentID);
        let tags: HTMLElement = document.getElementById(this.tagsID);
        let button: HTMLElement = document.getElementById(this.buttonsID);
        title.style.display = "none";
        content.style.display = "none";
        tags.style.display = "none";
        button.style.display = "none";
    }

    //Insert HTML to represent editor and add the get strings to them.
    private InsertEditor(): void {
        let title = this.GetTitle();
        let content = this.GetContent();
        let tags = this.GetTags();
        document.getElementById(this.editorID).innerHTML =
            // TODO: Find out why this is broken. Producing a 400 error. Client side problem.
            `
<div class="text-center">
    <h1>Modify Article</h1>
    <form method="post" class="form-group text-left">
        <br/>
        <div class="btn-toolbar" role="toolbar">
            <div class="btn-group" role="group">
                <button type="button"
                    class="btn btn-outline-dark"
                    name="bold"
                    onclick="insertHTMLCode('b')">
                <b> B </b>
                </button>
                <button type="button"
                    class="btn btn-outline-dark"
                    name="italic"
                    onclick="insertHTMLCode('i')">
                <i> I </i>
                </button>
                <button
                    type="button"
                    class="btn btn-outline-dark"
                    name="code"
                    onclick="insertHTMLCode('c')">
                Code
                </button>
            </div>
        </div>
        <label for="newTitle">Title:</label>
        <input type="text" id="newTitle" class="form-control" value = title />
        <label for="newTags">Tags:</label>
        <input type="text" id="newTags" class="form-control" value = tags />
        <label for="newContent">Content:</label>
        <textarea class="form-control"
            id="newContent"
            rows="10"
            cols="80"> 
        </textarea>
        <br/>
        <button type="submit" class="btn btn-primary">Submit</button>
    </form>
</div>
<script>
    function insertHTMLCode(input) {
        let content = document.getElementById("newContent");
        switch(input) {
            case 'i':
                content.value += "<i></i>";
                break;
            case 'b':
                content.value += "<b></b>";
                break;
            case 'c':
                content.value += "\\n<pre>\\n<code>\\n Insert snippet here\\n</code>\\n</pre>\\n";
                break;
        }
    }
</script>
    `;
      
        let initContent: HTMLElement = document.getElementById("newContent");
        (<HTMLInputElement>initContent).value += content;
    }

    // Return the text of the title.
    private GetTitle = (): string =>
        document.getElementById(this.titleID).innerHTML;

    // Return the text of the content.
    private GetContent = (): string =>
        document.getElementById(this.contentID).innerHTML;

    private GetTags = (): string =>
        document.getElementById(this.contentID).innerHTML;
}

