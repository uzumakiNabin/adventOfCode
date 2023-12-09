const { readFile } = require("fs");

readFile("input.txt", { encoding: "utf-8" }, (err, text) => {
  let count = 0;
  let instr = text.trim().split(/\r\n/);
  instr = instr.map((ky) =>
    ky
      .trim()
      .split(/\s+/)
      .map((sd) => +sd)
  );
  let newInstr = [];
  for (let i = 0; i < instr.length; i += 3) {
    for (let j = 0; j < 3; j += 1) {
      newInstr.push([instr[i][j], instr[i + 1][j], instr[i + 2][j]]);
    }
  }
  newInstr.forEach((sides) => {
    if (is_possible(sides)) {
      count += 1;
    }
  });
  console.log(`${count} triangles are valid.`);
});

const is_possible = (tri) =>
  tri[0] + tri[1] > tri[2] &&
  tri[1] + tri[2] > tri[0] &&
  tri[2] + tri[0] > tri[1];
