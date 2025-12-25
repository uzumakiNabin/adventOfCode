package main

import (
	"aoc2025/day11"
	"fmt"
	"time"
)

func timer() func() {
	start := time.Now()
	return func() {
		fmt.Printf("exec time %v\n", time.Since(start))
	}
}

func main() {
	defer timer()()
	day11.Part2()
}
