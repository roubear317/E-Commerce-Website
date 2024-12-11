/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [ "./src/**/*.{html,ts}",
    "./node_modules/flowbite/**/*.js"
  ],
  theme: {
    extend: {
      colors: {
        customGold: "rgb(176,125,67)", 
        customPink: "rgb(224,123,136)",
      },
    },
  },
  plugins: [


    require('flowbite/plugin')
  ],
}

