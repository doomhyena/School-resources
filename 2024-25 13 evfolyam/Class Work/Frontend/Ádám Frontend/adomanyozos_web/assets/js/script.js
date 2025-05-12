const donations = [];
const maxDays = 10;
const weeklyGoal = 1000;

document.getElementById('add-donation').addEventListener('click', () => {
    const input = document.getElementById('donation-input');
    const amount = parseFloat(input.value);
    if (!isNaN(amount) && amount > 0) {
        donations.push(amount);
        if (donations.length > maxDays) donations.shift();
        updateTracker();
    }
    input.value = '';
});

function updateTracker() {
    const donationList = document.getElementById('donation-list');
    donationList.innerHTML = '';
    donations.forEach(amount => {
        const box = document.createElement('div');
        box.className = 'donation-box';
        box.textContent = `${amount} Euró`;
        donationList.appendChild(box);
    });

    const total = donations.reduce((sum, val) => sum + val, 0);
    const average = (total / donations.length).toFixed(2);
    const highest = Math.max(...donations, 0);
    const progress = Math.min((total / weeklyGoal) * 100, 100);

    document.getElementById('total-amount').textContent = total;
    document.getElementById('average-donation').textContent = average;
    document.getElementById('highest-donation').textContent = highest;
    document.getElementById('current-progress').textContent = total;
    document.getElementById('progress-fill').style.width = `${progress}%`;
}

document.getElementById('scroll-to-donations').addEventListener('click', () => {
    const donationSection = document.getElementById('donation-section');
    donationSection.scrollIntoView({ behavior: 'smooth' });
});