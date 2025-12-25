package day7

import (
	"aoc2025/utils"
	"fmt"
	"os"
	"regexp"
	"slices"
	"strings"
)

func Part1() {
	file, err := os.ReadFile("D:\\Projects\\aoc\\2025\\day7\\input")
	if err != nil {
		fmt.Println("Error opening file:", err)
		return
	}
	input := string(file)
	re := regexp.MustCompile(`\r\n|\n|\r`)
	lines := re.Split(input, -1)
	firstLine := lines[0]
	lines = lines[1:]
	var beamPositions []int
	beamPositions = append(beamPositions, strings.IndexRune(firstLine, 'S'))
	var newPositions []int

	count := 0
	for _, line := range lines {
		newPositions = utils.DeepCopy(beamPositions)
		for _, pos := range beamPositions {
			if string(line[pos]) == "^" {
				newPositions = utils.RemoveItemFromSlice(newPositions, pos)
				newPositions = insertUnique(newPositions, pos-1)
				newPositions = insertUnique(newPositions, pos+1)
				count++
			}
		}
		beamPositions = utils.DeepCopy(newPositions)
	}

	fmt.Println(count)
}

func insertUnique(s []int, itm int) []int {
	if slices.Contains(s, itm) {
		return s
	} else {
		return append(s, itm)
	}
}
