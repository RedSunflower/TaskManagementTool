import AbstractTask from "./abstractTask.js";
export default class SubTask extends AbstractTask {
    constructor(setup) {
        super(setup);
    }

    appendProgress() {
        let progress = 0;
        if (this.getStatus === "Done") {
            progress = 100;
        }
        $(".id-" + this.getId + " .progress-bar").css("width", progress + "%").text(progress + "%");
    }
}
