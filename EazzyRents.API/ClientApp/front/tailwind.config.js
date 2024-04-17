/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      height: {
        '1/4-screen': '25vh'
      }
    },
  },
  plugins: [],
}

