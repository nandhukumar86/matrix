function calculateDimensions(startingGrid, dimension) {
    const A4_WIDTH = 210;
    const A4_HEIGHT = 297;
    const COLUMNS = 12;
    const ROWS = 20;

    const columnWidth = A4_WIDTH / COLUMNS;
    const rowHeight = A4_HEIGHT / ROWS;

    const [x, y] = startingGrid; // Zero-based index
    const [l, h] = dimension;

    // Calculate starting position in mm
    const startX = x * columnWidth;
    const startY = y * rowHeight;

    // Calculate object size in mm
    const objectWidth = l * columnWidth;
    const objectHeight = h * rowHeight;

    return {
        startingPoint: { x: startX, y: startY },
        dimensions: { width: objectWidth, height: objectHeight }
    };
}

// Example usage
const result = calculateDimensions([11, 19], [1, 1]); // Zero-based index
console.log(result);
