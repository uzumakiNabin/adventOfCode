const { readFile } = require("fs");

readFile("input.txt", { encoding: "utf-8" }, (err, text) => {
  let instr = text.split(", ");
  console.log(`${AoCd1p2(instr)} is first visited twice`);
});

const AoCd1p2 = (directions) => {
  const nav = {
      n: { L: "w", R: "e", plane: "y", offset: 1 },
      e: { L: "n", R: "s", plane: "x", offset: 1 },
      s: { L: "e", R: "w", plane: "y", offset: -1 },
      w: { L: "s", R: "n", plane: "x", offset: -1 },
    },
    mem = { x0y0: true };

  let key;

  return Object.values(
    directions.reduce(
      (state, dir) => {
        if (state.found) return state;

        state.dir = nav[state.dir[dir[0]]];

        for (let i = 0, j = +dir.slice(1); i < j && !state.found; i++) {
          state.pos[state.dir.plane] += state.dir.offset;
          key = `x${state.pos.x}y${state.pos.y}`;

          if (mem[key]) state.found = true;
          else mem[key] = true;
        }

        return state;
      },
      { dir: nav.n, pos: { x: 0, y: 0 }, found: false }
    ).pos
  ).reduce((sum, val) => sum + Math.abs(val), 0);
};
