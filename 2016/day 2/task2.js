const { readFile } = require("fs");

readFile("input.txt", { encoding: "utf-8" }, (err, text) => {
  let keypad = [
    ["", "", 1, "", ""],
    ["", 2, 3, 4, ""],
    [5, 6, 7, 8, 9],
    ["", "A", "B", "C", ""],
    ["", "", "D", "", ""],
  ];
  const addX = (i) => {
    if (y === 0 || y === 4) {
      return i;
    } else if (y === 1 || y === 3) {
      return i + 1 > 3 ? 3 : i + 1;
    } else {
      return i + 1 > 4 ? 4 : i + 1;
    }
  };
  const addY = (i) => {
    if (x === 0 || x === 4) {
      return i;
    } else if (x === 1 || x === 3) {
      return i + 1 > 3 ? 3 : i + 1;
    } else {
      return i + 1 > 4 ? 4 : i + 1;
    }
  };
  const subtrX = (i) => {
    if (y === 0 || y === 4) {
      return i;
    } else if (y === 1 || y === 3) {
      return i - 1 < 1 ? 1 : i - 1;
    } else {
      return i - 1 < 0 ? 0 : i - 1;
    }
  };
  const subtrY = (i) => {
    if (x === 0 || x === 4) {
      return i;
    } else if (x === 1 || x === 3) {
      return i - 1 < 1 ? 1 : i - 1;
    } else {
      return i - 1 < 0 ? 0 : i - 1;
    }
  };
  let x = 2,
    y = 0,
    password = "";
  let instr = text.trim().split(/\r\n/);
  instr.forEach((ky) => {
    for (let i = 0; i < ky.length; i++) {
      switch (ky[i]) {
        case "U":
          x = subtrX(x);
          break;
        case "D":
          x = addX(x);
          break;
        case "L":
          y = subtrY(y);
          break;
        case "R":
          y = addY(y);
          break;
        default:
          break;
      }
    }
    password = password.concat(keypad[x][y]);
  });
  console.log(`password is ${password}`);
});
