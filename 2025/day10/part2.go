package day10

import (
	"fmt"
	"os"
	"regexp"
	"strconv"
	"strings"
)

func Part2() {
	file, err := os.ReadFile("D:\\Projects\\aoc\\2025\\day10\\input")
	if err != nil {
		fmt.Println("Error opening file:", err)
		return
	}
	input := string(file)
	re := regexp.MustCompile(`\r\n|\n|\r`)
	lines := re.Split(input, -1)

	var machines []Machine
	for _, line := range lines {
		split := strings.Fields(line)
		tgt := split[0]
		tgt = tgt[1:(len(tgt) - 1)]
		machines = append(machines, Machine{tgt, parseButtons(split[1:(len(split) - 1)]), parseJoltage(split[len(split)-1])})
	}

	// bfs implementation
	result := 0
	// for _, machine := range machines {
	// 	var buttonMatrix [][]int
	// 	for _, button := range machine.buttons {

	// 	}

	// }

	fmt.Println(result)
}

func getJoltageString(joltage []int) string {
	res := ""
	for _, j := range joltage {
		res += strconv.Itoa(j) + ","
	}
	return res[0:(len(res) - 1)]
}

func skipIteration(joltage string, target []int) bool {
	joltageValue := strToIntSlice(joltage)
	for i, v := range joltageValue {
		if v > target[i] {
			return true
		}
	}
	return false
}
