const fs = require('fs');

// Đường dẫn tới tệp vn.json và en.json
const sourceFilePath = './locales/vn.json';
const targetFilePath = './locales/en10.json';

// Đọc nội dung từ tệp vn.json
const sourceData = JSON.parse(fs.readFileSync(sourceFilePath, 'utf-8'));

// Hàm đệ quy để thêm "_EN" vào các giá trị dịch cho tiếng Anh
function addENTranslation(obj) {
  if (typeof obj === 'string') {
    return `${obj}_EN`;
  } else if (typeof obj === 'object') {
    const newObj = {};
    for (const key in obj) {
      newObj[key] = addENTranslation(obj[key]);
    }
    return newObj;
  }
  return obj;
}

// Sao chép nội dung và thêm "_EN" vào các giá trị dịch cho tiếng Anh
const targetData = addENTranslation(sourceData);

// Ghi vào tệp en.json
fs.writeFileSync(targetFilePath, JSON.stringify(targetData, null, 2), 'utf-8');

console.log('Tệp en.json đã được tạo thành công.');
