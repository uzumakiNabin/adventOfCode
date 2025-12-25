package utils

import "slices"

func RemoveItemFromSlice[T comparable](s []T, itm T) []T {
	idx := slices.Index(s, itm)
	if idx == 0 {
		return s[1:]
	} else if idx == (len(s) - 1) {
		return s[0:(len(s) - 1)]
	} else {
		return append(s[0:idx], s[idx+1:]...)
	}
}

func RemoveIndexFromSlice[T any](s []T, idx int) []T {
	if idx == 0 {
		return s[1:]
	} else if idx == (len(s) - 1) {
		return s[0:(len(s) - 1)]
	} else {
		return append(s[0:idx], s[idx+1:]...)
	}
}
