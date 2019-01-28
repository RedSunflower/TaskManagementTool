import AbstractTask from "./abstractTask.js";

export default class Setup extends AbstractTask {
    constructor(item) {
        super(item)
    }
    set setId(item) {
        this.id = item.dataset.title;
    }

    set setParentId(item) {
        this.parentId = item.dataset.content;
    }

    set setStatus(item) {
        this.status = item.innerText
    }
}