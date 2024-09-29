const container = document.querySelector(".container");
const filterForm = document.querySelector("form");
const addResumeButton = document.querySelector("#addResumeButton");
const resumeList = [];

document.addEventListener("DOMContentLoaded", async (event) => {
    await loadResumes(resumeList);
});


//OPERATION: ADD RESUME
addResumeButton.addEventListener("click", (event) => {
    window.location.href = "add.html";
})

//OPERATION: FILTER
filterForm.addEventListener("submit", (event) => {
    event.preventDefault();

    const filteredList = filterByResumes(resumeList);
    const orderedList = orderByResumes(filteredList);
    clearResumes();
    loadResumesRepresentations(orderedList);
});

function filterByResumes(list) {
    let filteredList = list;

    const nameFilter = filterForm.elements.nameFilter.value;
    const marriedFilter = filterForm.elements.marriedFilter.value;
    const phoneFilter = filterForm.elements.phoneFilter.value;

    const startBirthFilter = filterForm.elements.startBirthFilter.value;
    const endBirthFilter = filterForm.elements.endBirthDate.value;

    console.log(startBirthFilter);
    console.log(endBirthFilter);

    const startSalaryFilter = filterForm.elements.startSalaryFilter.value;
    const endSalaryFilter = filterForm.elements.endSalaryFilter.value;

    if (nameFilter !== null && nameFilter !== "") {
        filteredList = filteredList.filter(resume => resume.name.toLowerCase().includes(nameFilter.toLowerCase()));
    }
    if (marriedFilter !== null && marriedFilter !== "") {
        filteredList = filteredList.filter(resume => resume.married === (marriedFilter === "1" ? true : false));
    }
    if (phoneFilter !== null && phoneFilter !== "") {
        filteredList = filteredList.filter(resume => resume.phone.includes(phoneFilter));
    }
    if ((startBirthFilter != null && startBirthFilter !== "") && (endBirthFilter !== null && endBirthFilter !== "")) {
        filteredList = filteredList.filter(resume => new Date(resume.birthDate) >= new Date(startBirthFilter) && new Date(resume.birthDate) <= new Date(endBirthFilter));
    }
    if ((startSalaryFilter != null && startSalaryFilter != "") && (endSalaryFilter != null && endSalaryFilter != "")) {
        filteredList = filteredList.filter(resume => resume.salary >= startSalaryFilter && resume.salary <= endSalaryFilter);
    }

    return filteredList;
}
function orderByResumes(list) {
    const orderByValue = filterForm.elements.orderByInput.value;

    switch (orderByValue) {

        case "name":
            return list.sort((a, b) => a.name.localeCompare(b.name));

        case "name-desc":
            return list.sort((a, b) => b.name.localeCompare(a.name))

        case "birth-date":
            return list.sort((a, b) => new Date(a.birthDate) - new Date(b.birthDate));

        case "birth-date-desc":
            return list.sort((a, b) => new Date(b.birthDate) - new Date(a.birthDate));

        case "married":
            return list.sort((a, b) => Number(a.married) - Number(b.married));

        case "married-desc":
            return list.sort((a, b) => Number(b.married) - Number(a.married));

        case "phone":
            return list.sort((a, b) => a.phone.localeCompare(b.phone));

        case "phone-desc":
            return list.sort((a, b) => b.phone.localeCompare(a.phone));

        case "salary":
            return list.sort((a, b) => a.salary - b.salary);

        case "salary-desc":
            return list.sort((a, b) => b.salary - a.salary);

        default:
            return list;
    }
}

//OPERATION: LOAD
async function loadResumes() {
    await loadResumesData();
    loadResumesRepresentations(resumeList);
}
function loadResumesRepresentations(list) {
    for (resume of list) {
        const resumeDisplay = createResumeDisplayHtml(resume);
        container.appendChild(resumeDisplay);
    }

    setEditButtonsListener();
    setDeleteButtonsListener();
}
async function loadResumesData() {
    try {
        const response = await axios.get(`https://localhost:5003/resumes`);
        resumeList.length = 0;
        for (resume of response.data) {
            resumeList.push(resume);       }

    } catch (e) {
        console.log("Exception", e);
        alert ("An error occurred while loading the resumes!");
    }
}
function createResumeDisplayHtml(resume) {
    const innerHtml =
        `
        <p class="col">${resume.name}</p>
        <p class="col">${resume.birthDate}</p>
        <p class="col">${resume.married ? "Yes" : "No"}</p>
        <p class="col">${resume.phone}</p>
        <p class="col">${resume.salary}$</p>
        <div class="col">
            <button type="button" class="btn btn-primary edit-btn" entity-id="${resume.id}">Edit</button>
            <button type="button" class="btn btn-danger delete-btn" entity-id="${resume.id}">Remove</button>
        </div>
    `;

    const rowDiv = document.createElement("div");
    rowDiv.className = "row resume-element";
    rowDiv.innerHTML = innerHtml;

    return rowDiv;
}

// OPERATION: REMOVE
async function removeResume(entityId) {
    try {
        await axios.delete(`https://localhost:5003/resumes/${entityId}`);

        alert("Resume removed successfully!");
        clearResumes();
        await loadResumes();

    } catch (e) {
        console.log("Exception", e);
        alert("An error occurred while removing the resume!");
    }
}
function setDeleteButtonsListener() {
    const deleteButtons = document.querySelectorAll(".delete-btn");
    deleteButtons.forEach(button => {
        button.addEventListener("click", async function () {
            const entityId = this.getAttribute("entity-id");
            await removeResume(entityId);
        })
    })
}
function clearResumes() {
    const resumeDivs = document.querySelectorAll(".resume-element");
    resumeDivs.forEach(div => div.remove());
}

//OPERATION: EDIT
function setEditButtonsListener() {
    const editButtons = document.querySelectorAll(".edit-btn");
    editButtons.forEach(button => {
        button.addEventListener('click', function () {
            const entityId = this.getAttribute("entity-id");
            window.location.href = `edit.html?entity-id=${entityId}`;
        });
    });
}