import Setup from "./modules/setup.js";
import Task from "./modules/task.js";


$(document).ready(function () {
    let records = [...$(".status-state")];
    let tasks = [];
    records.forEach(function (record, index, records) {
        let task = new Task(new Setup(record));
        task.setSubTasks = records;
        task.setQuantitySubTasks = task.getSubTasks;
        task.incrementQuantityDoneSubTasks = task.getSubTasks;
        if (task.getParentId === "0") {
            tasks.push(task);
            task.appendProgress();
        }
    });
});