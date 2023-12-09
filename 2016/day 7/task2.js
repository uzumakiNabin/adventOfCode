const { readFile } = require("fs");

readFile("input.txt", { encoding: "utf-8" }, (err, text) => {
  let instr = text.split(/\r\n/);
  let count = 0;
  instr.forEach((ky) => {
    let abba = [];
    let hNetSeq = [];
    let tempStr = "";
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
    if (checkAba(abba, hNetSeq)) {
      count += 1;
    }
  });
  console.log(`${count} IPs support SSL.`);
});

const checkAba = (aba, bab) => {
  let result = false;
  aba.forEach((str) => {
    if (str.length < 3) return;
    if (result) return;
    for (let i = 0; i < str.length; i += 1) {
      if (result) break;
      if (
        str.charAt(i) !== str.charAt(i + 1) &&
        str.charAt(i) === str.charAt(i + 2)
      ) {
        let key = str.charAt(i + 1) + str.charAt(i) + str.charAt(i + 1);
        bab.forEach((babStr) => {
          if (babStr.includes(key)) {
            result = true;
            return;
          }
        });
      }
    }
  });
  return result;
};
