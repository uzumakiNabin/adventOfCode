package day2

import (
	"fmt"
	"os"
	"strconv"
	"strings"
)

func Part2() {
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
			if hasRepeatedPattern(i) {
				sum += i
			}
		}
	}
	fmt.Println(sum)
}

func hasRepeatedPattern(n int) bool {
	st := strconv.Itoa(n)
	loopLimit := len(st) / 2
	result := false
	for i := 1; i <= loopLimit; i++ {
		if len(st)%i != 0 {
			continue
		}
		if st[0:i] == st[i:i*2] {
			result = isFullyRepeated(st, i)
			if result {
				break
			}
		} else {
			continue
		}
	}
	return result
}

func isFullyRepeated(st string, bufferSize int) bool {
	loopLimit := len(st) - (bufferSize * 2)
	for i := 0; i <= loopLimit; i += bufferSize {
		if st[i:i+bufferSize] != st[i+bufferSize:i+bufferSize*2] {
			return false
		}
	}
	return true
}
