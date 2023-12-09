const { readFile } = require("fs");

readFile("input.txt", { encoding: "utf-8" }, (err, text) => {
  let instr = text.trim().split(/\r\n/);
  let count = 0;
  instr.forEach((ky) => {
    let abba = [];
    let hNetSeq = [];
    let tempStr = "";
    let isValid = false;
    for (let i = 0; i < ky.length; i += 1) {
      if (ky[i] === "[") {
        abba.push(tempStr);
        tempStr = "";
        continue;
      } else if (ky[i] === "]") {
        hNetSeq.push(tempStr);
        tempStr = "";
        continue;
      }
      tempStr = tempStr.concat(ky[i]);
    }
    if (tempStr.length > 0) {
      abba.push(tempStr);
      tempStr = "";
    }
    abba.forEach((str) => {
      if (checkAbba(str)) {
        isValid = true;
        return;
      }
    });
    hNetSeq.forEach((str) => {
      if (checkAbba(str)) {
        isValid = false;
        return;
      }
    });
    if (isValid) {
      count += 1;
    }
  });
  console.log(`${count} IPs support TLS.`);
});

const checkAbba = (str) => {
  if (str.length < 4) return false;
  for (let i = 0; i < str.length - 3; i += 1) {
    if (
      str.charAt(i) !== str.charAt(i + 1) &&
      str.substring(i, i + 2) === str.charAt(i + 3) + str.charAt(i + 2)
    ) {
      return true;
    }
  }
  return false;
};
