class ModifyArticle {
    readonly titleID: string;
    readonly contentID: string;
    readonly buttonsID: string;
    readonly tagsID: string;

    constructor( tiID: string
        , conID: string
        , butID: string
        , tagID: string) {
        this.titleID = tiID;
        this.contentID = conID;
        this.buttonsID = butID;
        this.tagsID = tagID;
    }

//Pushes all the content into input boxes for modification. On post should be called with updated strings.
    public ModifyAll(): void {
        this.GetTitle(this.titleID);
        this.ModifyContent(this.contentID);
        this.ModifyButtons(this.buttonsID);
        this.ModifyTags(this.tagsID);
    }
    
    GetTitle(titleID: string): void {
       let title: HTMLElement = document.getElementById(titleID);
       let preTitle: string = document.getElementById(titleID).innerText;
       title.innerHTML = "<div name = \"Article.Title\"></div>";
       title.innerText = preTitle;
    }
    
    ModifyContent(contentID: string): void {
        let content: HTMLElement = document.getElementById(contentID);
        let preContent: string = document.getElementById(contentID).innerHTML;
        content.innerHTML = `<textarea class = "form-control"
                                            id = "modifyContent"
                                            name = "Article.Content"
                                            rows = "10"
                                            cols = "70"></textarea>`;
        let modifyContent: HTMLElement = document.getElementById("modifyContent");
        (<HTMLInputElement>modifyContent).value += preContent;
    }

    ModifyButtons(buttonsID: string): void {
        let buttons: HTMLElement = document.getElementById(buttonsID);
        buttons.innerHTML = `<button type="submit" class = "btn btn-primary"> Submit </button>
                         <button class = "btn btn-danger" onclick="window.location.reload()">Cancel</button>`;
    }
    
    ModifyTags(tagsID: string): void {
        let tags: HTMLElement = document.getElementById(tagsID);
        let preTags: string = document.getElementById(tagsID).innerHTML;
        tags.innerHTML = `<input type="text" id="modifyTags" name="Article.Tags" class="form-control" />`
        let modifyTags: HTMLElement = document.getElementById("modifyTags");
        (<HTMLInputElement>modifyTags).value += preTags;
    }
}