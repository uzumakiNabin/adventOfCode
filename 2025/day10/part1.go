package day10

import (
	"fmt"
	"os"
	"regexp"
	"slices"
	"strconv"
	"strings"
)

type Machine struct {
	target  string
	buttons [][]int
	joltage []int
}

func Part1() {
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
	for _, machine := range machines {
		initial := strings.ReplaceAll(machine.target, "#", ".")
		visited := map[string]int{initial: 0}
		queue := []string{initial}
		res := -1
		queueIdx := 0
		for {
			item := queue[queueIdx]
			queueIdx++
			if item == machine.target {
				res = visited[item]
				break
			}
			for _, button := range machine.buttons {
				buttonRes := ""
				for i, c := range item {
					if slices.Contains(button, i) {
						if string(c) == "." {
							buttonRes += "#"
						} else {
							buttonRes += "."
						}
					} else {
						buttonRes += string(c)
					}
				}
				_, ok := visited[buttonRes]
				if !ok {
					visited[buttonRes] = visited[item] + 1
					queue = append(queue, buttonRes)
				}
			}
		}
		result += res
	}

	fmt.Println(result)
}

func parseButtons(strs []string) [][]int {
	var res [][]int
	for _, s := range strs {
		res = append(res, strToIntSlice(s[1:(len(s)-1)]))
	}
	return res
}

func parseJoltage(str string) []int {
	return strToIntSlice(str[1:(len(str) - 1)])
}

func strToIntSlice(str string) []int {
	split := strings.Split(str, ",")
	res := make([]int, len(split))
	for i, s := range split {
		res[i], _ = strconv.Atoi(s)
	}
	return res
}
