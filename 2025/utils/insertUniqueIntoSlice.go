package utils

import "slices"

func InsertUniqueIntoSlice[T comparable](s []T, itm T) []T {
	if slices.Contains(s, itm) {
		return s
	} else {
		return append(s, itm)
	}
}
