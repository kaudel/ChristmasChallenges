package main

import "fmt"


	func main() {
		seconds := 0
		leds := []int{0, 0, 1, 0, 0}
		ledsFinal := make([]int, len(leds))
		copy(ledsFinal, leds)
		ledsSize := len(leds) - 1 //5

		for {
			var isZero = false
			for x, s := range leds {
				if s == 1 {
					print(s)
				} else {
					if x == 0 {
						if leds[ledsSize] == 1 {
							ledsFinal[x] = 1
						}
						print(leds[x])
					} else {
						if leds[x-1] == 1 {
							ledsFinal[x] = 1
						}
						print(leds[x])
					}
				}

				if leds[x] == 0 {
					isZero = true
				}
				seconds = x
			}

			copy(leds, ledsFinal)
			println("")

			if !isZero {
				break
			}
		}

		fmt.Printf("It will take: %d seconds ", seconds*7)

}