import AbstractTask from "./abstractTask.js";
import SubTask from "./subTask.js";
import Setup from "./setup.js";
export default class Task extends AbstractTask {
    constructor(setup) {
        super(setup);
        this.subTasks = [];
        this.quantitySubTasks = 0;
        this.quantityDoneSubTasks = 0;
    }

    addSubTask(subTask) {
        this.subTasks.push(subTask)
    }

    get getSubTasks() {
        return this.subTasks;
    }

    set setQuantitySubTasks(subTasks) {
        this.quantitySubTasks = subTasks.length;
    }

    get getQuantitySubTasks() {
        return this.quantitySubTasks;
    }

    set setQuantityDoneSubTasks(numberOfDone) {
        this.quantityDoneSubTasks = numberOfDone;
    }

    set incrementQuantityDoneSubTasks(subTasks) {
        let numberOfDone = 0;
        if (this.getQuantitySubTasks > 0) {
            subTasks.forEach(function (subTask) {
                if (subTask.getStatus === "Done") {
                    numberOfDone++;
                }
            });
        }
        this.setQuantityDoneSubTasks = numberOfDone;
    }

    get getQuantityDoneSubTasks() {
        return this.quantityDoneSubTasks;
    }

    set setSubTasks(records) {
        for (let i = 0; i < records.length; i++) {
            if (this.getId === records[i].dataset.content) {
                let subTask = new SubTask(new Setup(records[i]));
                this.addSubTask(subTask);
                subTask.appendProgress();
            }
        }
    }

    appendProgress() {
        let progress = 0;
        if (this.getQuantityDoneSubTasks > 0) {
            progress = (this.getQuantityDoneSubTasks / this.getQuantitySubTasks) * 100;
        }
        if (this.getStatus === "Done") {
            progress = 100;
        }
        $(".id-" + this.getId + " .progress-bar").css("width", progress + "%").text(progress + "%");
    }

}