const { readFile } = require("fs");

readFile("input.txt", { encoding: "utf-8" }, (err, text) => {
  let direction = "N";
  let x = 0,
    y = 0;
  let instr = text.split(", ");
  console.log;
  instr.forEach((ky) => {
    switch (direction) {
      case "N":
        if (ky.substr(0, 1) === "L") {
          x = x - +ky.substr(1);
          direction = "W";
        } else {
          x = x + +ky.substr(1);
          direction = "E";
        }
        break;
      case "S":
        if (ky.substr(0, 1) === "L") {
          x = x + +ky.substr(1);
          direction = "E";
        } else {
          x = x - +ky.substr(1);
          direction = "W";
        }
        break;
      case "E":
        if (ky.substr(0, 1) === "L") {
          y = y + +ky.substr(1);
          direction = "N";
        } else {
          y = y - +ky.substr(1);
          direction = "S";
        }
        break;
      case "W":
        if (ky.substr(0, 1) === "L") {
          y = y - +ky.substr(1);
          direction = "S";
        } else {
          y = y + +ky.substr(1);
          direction = "N";
        }
        break;
      default:
        break;
    }
  });
  let blocks = Math.abs(x) + Math.abs(y);

  console.log(`Easter Bunny HQ is ${blocks} blocks away.`);
});
