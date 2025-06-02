// 1.feladat:

function osszefuz(arr1, arr2) {
    return  [...arr1, ...arr2];
}

console.log("--- 1.feladat ---");
console.log(osszefuz([1, 2, 3], [4, 5, 6]));

// 2.feladat:

function variaciok(arr) {
    const eredmeny = [];
    function permutacio(akt, maradek) {
        if (maradek.length === 0) {
            eredmeny.push(akt);
            return;
        }
        for (let i = 0; i < maradek.length; i++) {
            permutacio([...akt, maradek[i]], [...maradek.slice(0, i), ...maradek.slice(i + 1)]);
        }
    }
    permutacio([], arr);
    return eredmeny;
}

console.log("--- 2.feladat ---");
console.log(variaciok([1, 2, 3]));

// 3.feladat:

function leghosszabbegydi(s) {
    let maxHossz = 0, start = 0;
    const indexek = [];
    for (let i = 0; i < s.length; i++) {
        if (s.indexOf(s[i]) === i) {
            let j = i;
            while (j < s.length && s.indexOf(s[j]) === i) {
                j++;
            }
            if (j - i > maxHossz) {
                maxHossz = j - i;
                start = i;
            }
        }
    }
    for (let i = start; i < start + maxHossz; i++) {
        indexek.push(i);
    }
    return indexek;
}

// 4.feladat:

function matrixszorzas(A, B) {
    const sorok1 = A.length, oszlopok1 = A[0].length;
    const sorok2 = B.length, oszlopok2 = B[0].length;

    if(oszlopok1 !== sorok2) {
        throw new Error("A mátrixok nem szorozhatók össze!");
    }

    const eredmeny = Array.from({ length: sorok1 }, () => Array(oszlopok2).fill(0));
    for (let i = 0; i < sorok1; i++) {
        for (let j = 0; j < oszlopok2; j++) {
            for (let k = 0; k < oszlopok1; k++) {
                eredmeny[i][j] += A[i][k] * B[k][j];
            }
        }
    }
    return eredmeny;
}

const A = [
    [1, 2],
    [3, 4]
]


const B = [
    [5, 6],
    [7, 8]
]

console.log("--- 4.feladat ---");
console.log(matrixszorzas(A, B));
