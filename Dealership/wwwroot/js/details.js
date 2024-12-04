let currentIndex = 0;

function setMainImage(index) {
    currentIndex = index;
    document.getElementById("mainImage").src = imageUrls[currentIndex];
}

function nextImage() {
    if (imageUrls.length === 0) return;
    currentIndex = (currentIndex + 1) % imageUrls.length; // Loop back to the first image
    document.getElementById("mainImage").src = imageUrls[currentIndex];
}

function previousImage() {
    if (imageUrls.length === 0) return;
    currentIndex = (currentIndex - 1 + imageUrls.length) % imageUrls.length; // Loop back to the last image
    document.getElementById("mainImage").src = imageUrls[currentIndex];
}
