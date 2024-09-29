const clearButton = document.querySelector("#clearButton");
const form = document.querySelector("form");

document.addEventListener("DOMContentLoaded", async (event) => {
    const entityId = getResumeId();

    try {
        const response = await axios.get(`https://localhost:5003/resumes/${entityId}`);
        setResumeData(response.data);

    } catch (e) {
        console.log("Exception", e);
        alert("An error occurred while loading the resume to be edited!");
    }
});

form.addEventListener("submit", async (event) => {
    event.preventDefault();

    const resume = getResumeData();
    const entityId = getResumeId();

    try {
        await axios.put(`https://localhost:5003/resumes/${entityId}`, resume);
        alert("Resume updated successfully!");
        window.location.href = "index.html";

    } catch (e) {
        console.log("Exception", e);
        alert("An error occurred while updating the resume!");
    }
})

clearButton.addEventListener("click", (event) => {
    clearForm();
});

function setResumeData(resume) {
    form.elements.nameInput.value = resume.name;
    form.elements.birthDateInput.value = resume.birthDate;
    form.elements.marriedInput.value = resume.married ? "1" : "2";
    form.elements.phoneInput.value = resume.phone;
    form.elements.salaryInput.value = resume.salary;
}

function getResumeData() {
    const resume = {
        name: form.elements.nameInput.value,
        birthDate: form.elements.birthDateInput.value,
        married: form.elements.marriedInput.value === "1" ? true : false,
        phone: form.elements.phoneInput.value,
        salary: form.elements.salaryInput.value
    }

    return resume;
}

function clearForm() {
    form.elements.nameInput.value = "";
    form.elements.birthDateInput.value = "";
    form.elements.marriedInput.value = "";
    form.elements.phoneInput.value = "";
    form.elements.salaryInput.value = "";
}

function getResumeId() {
    const params = new URLSearchParams(window.location.search);
    const entityId = params.get("entity-id");

    return entityId;
}