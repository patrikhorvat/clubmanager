
const Home = {
    text: 'Dashboard',
    link: '/home',
    icon: 'icon-home'
};

const headingMain = {
    text: 'Glavni izbornik',
    heading: true
};

const players = {
  text: 'Igrači',
  link: '/players',
  icon: 'fas fa-bullseye'
};

const trainers = {
  text: 'Treneri',
  link: '/trainers',
  icon: 'fas fa-hand-holding'
};

const employees = {
  text: 'Zaposlenici',
  link: '/employees/overview',
  icon: 'fas fa-users'
};

const asset = {
  text: 'Imovina',
  link: '/assets',
  icon: 'fas fa-box'
};

export const menu = [
    headingMain,
  Home,
  players,
  trainers,
  employees,
    asset
];
