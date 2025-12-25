package day7

import (
	"aoc2025/utils"
	"fmt"
	"os"
	"regexp"
	"strings"
)

type Manifold struct {
	id     int
	childs []*Manifold
	idx    int
}

func Part2() {
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
	beamPositions := []int{strings.IndexRune(firstLine, 'S')}
	var newPositions []int

	id := 1
	startingManifold := Manifold{idx: beamPositions[0], id: 0}
	curr := []*Manifold{&startingManifold}

	for _, line := range lines {
		newPositions = utils.DeepCopy(beamPositions)
		var newCurr []*Manifold
		for _, pos := range beamPositions {
			if string(line[pos]) == "^" {
				newPositions = utils.RemoveItemFromSlice(newPositions, pos)
				newPositions = insertUnique(newPositions, pos-1)
				newPositions = insertUnique(newPositions, pos+1)
				var manifold1, manifold2 *Manifold
				manifold1, exists1 := findManifold(newCurr, pos-1)
				if !exists1 {
					manifold1 = &Manifold{idx: pos - 1, id: id}
					id++
				}
				manifold2, exists2 := findManifold(newCurr, pos+1)
				if !exists2 {
					manifold2 = &Manifold{idx: pos + 1, id: id}
					id++
				}
				parent, exists := findManifold(curr, pos)
				if exists {
					(*parent).childs = []*Manifold{manifold1, manifold2}
					if !exists1 {
						newCurr = append(newCurr, manifold1)
					}
					if !exists2 {
						newCurr = append(newCurr, manifold2)
					}
				}
			} else {
				var manifold1 *Manifold
				manifold1, exists1 := findManifold(newCurr, pos)
				if !exists1 {
					manifold1 = &Manifold{idx: pos, id: id}
					id++
				}
				parent, exists := findManifold(curr, pos)
				if exists {
					(*parent).childs = []*Manifold{manifold1}
					newCurr = append(newCurr, manifold1)
				}
			}
		}
		beamPositions = utils.DeepCopy(newPositions)
		curr = utils.DeepCopy(newCurr)
	}

	sumMemo := make(map[int]int)
	fmt.Println(getSum(startingManifold, sumMemo))
}

func findManifold(lst []*Manifold, idx int) (*Manifold, bool) {
	for _, itm := range lst {
		if (*itm).idx == idx {
			return itm, true
		}
	}
	return nil, false
}

func getSum(manifold Manifold, memo map[int]int) int {
	fmt.Println("memo", memo)
	if len(manifold.childs) < 1 {
		return 1
	} else {
		value, ok := memo[manifold.id]
		if ok {
			return value
		}
		res := 0
		for _, ch := range manifold.childs {
			res += getSum(*ch, memo)
		}
		memo[manifold.id] = res
		return res
	}
}
