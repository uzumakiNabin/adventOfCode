package day2

import (
	"fmt"
	"os"
	"strconv"
	"strings"
)

func Part1() {
	file, err := os.ReadFile("D:\\Projects\\aoc\\2025\\day2\\input")
	if err != nil {
		fmt.Println("Error opening file:", err)
		return
	}
	input := string(file)
	ranges := strings.SplitSeq(input, ",")
	sum := 0

	for rng := range ranges {
		rngSplit := strings.Split(rng, "-")
		start, err := strconv.Atoi(rngSplit[0])
		if err != nil {
			fmt.Println("Error parsing input", rng, err)
			break
		}
		end, err := strconv.Atoi(rngSplit[1])
		if err != nil {
			fmt.Println("Error parsing input", rng, err)
			break
		}
		for i := start; i <= end; i++ {
			if isRepeatedTwice(i) {
				sum += i
			}
		}
	}
	fmt.Println(sum)
}

func isRepeatedTwice(n int) bool {
	st := strconv.Itoa(n)
	if len(st)%2 == 1 {
		return false
	}
	firstHalf := st[0:(len(st) / 2)]
	secondHalf := st[(len(st) / 2):]
	return firstHalf == secondHalf
}
