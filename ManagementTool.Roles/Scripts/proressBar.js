var itemId = document.querySelectorAll('input[name="item.Id"]');
var itemParentId = document.querySelectorAll('input[name="item.ParentId"]');

function Task(id) {
    this.itemId = id; 
};
function Subtask(id) {
    this.parentId = id;
};

var tasks = [];
var subTasks = [];

for (var key = 0; key < itemId.length; key++) {
    tasks.push(new Task(itemId[key].value));
}

for (var key = 0; key < itemParentId.length; key++) {
    subTasks.push(new Subtask(itemParentId[key].value));
}

