import TaskError from "./taskError.js";
export default class AbstractTask {
    constructor(setup) {
        if (this.constructor === AbstractTask) {
            throw  new TaskError("Type error: cannot create an instance of abstract class!");
        }
        this.setId = setup;
        this.setParentId = setup;
        this.setStatus = setup;
    }

    set setId(setup) {
        if (setup.id !== undefined) {
            this.id = setup.id;
        }
    }

    get getId() {
        return this.id;
    }

    set setParentId(setup) {
        if (setup.parentId !== undefined) {
            this.parentId = setup.parentId;
        }
    }

    get getParentId() {
        return this.parentId;
    }

    set setStatus(setup) {
        this.status = setup.status;
    }

    get getStatus() {
        return this.status;
    }

    appendProgress() {
    }
}