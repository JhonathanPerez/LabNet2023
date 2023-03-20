const initialScore = 19;
let randomNumber = getRandomInt(20);
let score = initialScore;

let $alertGame = document.getElementById("alertBoxGame");
let $alertLostGame = document.getElementById("alertLostGame");
let $alertWinGame = document.getElementById("alertWinGame");
let $message = document.getElementById("message");
let $score = document.getElementById("score");
let $highScore = document.getElementById("highScore");
let $numbers = document.getElementById("numbers");
let inputNumbers = [];

$score.textContent = score;

function getRandomInt(max) {
  return Math.floor(Math.random() * max + 1);
}

if (!navigator.onLine) {
  alert("Conectate a internet");
  window.close();
}

console.log(randomNumber);

function juego() {
  let $number = document.getElementById("randomNumber").value;

  if (score == 1) {
    $alertGame.style.display = "none";
    $alertLostGame.style.display = "block";
    splashConfetti();
    return;
  }

  if ($number === "") {
    alert("Opss!! debes ingresar un número primero");
    return;
  }

  if ($number < 1) {
    $alertGame.style.display = "block";
    $message.textContent = "El número debe ser mayor que cero";
    return;
  }

  if ($number < randomNumber) {
    $alertGame.style.display = "block";
    $message.textContent = "Intenta con un número mayor";
    verifyNumber($number);
    document.getElementById("randomNumber").value = "";
    score -= 1;
    $score.textContent = score;
    return;
  }

  if ($number > randomNumber) {
    $alertGame.style.display = "block";
    $message.textContent = "Intenta con un número menor";
    verifyNumber($number);
    document.getElementById("randomNumber").value = "";
    score -= 1;
    $score.textContent = score;
    return;
  }

  $alertGame.style.display = "none";
  $alertWinGame.style.display = "block";
  splashConfetti("Win");
  document.getElementById("btnValidar").disabled = true;
  validateHighScore($score.textContent);
}

function verifyNumber(number) {
  $numbers.textContent = "";
  inputNumbers.push(number);

  inputNumbers.forEach((number) => {
    $numbers.textContent += `${number},`;
  });
}

function validateHighScore(score) {
  return score > parseInt($highScore.textContent)
    ? ($highScore.textContent = score)
    : parseInt($highScore.textContent);
}

function reset() {
  score = initialScore;
  $score.textContent = score;
  document.getElementById("randomNumber").value = "";
  inputNumbers = [];
  $numbers.textContent = "Aún no has ingresado números";
  $alertGame.style.display = "none";
  $alertLostGame.style.display = "none";
  $alertWinGame.style.display = "none";
  document.getElementById("btnValidar").disabled = false;
  randomNumber = getRandomInt(20);
}

function splashConfetti(state = "Lost") {
  const jsConfetti = new JSConfetti();

  if (state === "Win") {
    jsConfetti.addConfetti({
      confettiNumber: 90,
      emojiSize: 50,
      emojis: ["🎊", "🥳"],
    });
  } else {
    jsConfetti.addConfetti({
      confettiNumber: 90,
      emojiSize: 50,
      emojis: ["😢", "😭"],
    });
  }
}
