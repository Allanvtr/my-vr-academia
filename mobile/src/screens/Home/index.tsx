import * as S from './styles';
import { ScrollView } from 'react-native';
import { GalleryCard } from '../../components/GalleryCard';
import Ionicons from 'react-native-vector-icons/Ionicons';
import Logo from '../../components/Logo';
import { useAppNavigation } from '../../hooks/useAppNavigation';
import BottomBar from '../../components/BottomBar'

const data = [
  {
    title: 'Sala de Aula',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor.',
  },
  {
    title: 'Sala de Aula',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor.',
  },
  {
    title: 'Sala de Aula',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor.',
  },
  {
    title: 'Sala de Aula',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor.',
  },
  {
    title: 'Sala de Aula',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor.',
  },
  {
    title: 'Sala de Aula',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor.',
  },
  {
    title: 'Sala de Aula',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor.',
  },
  {
    title: 'Sala de Aula',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor.',
  },
  {
    title: 'Sala de Aula',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor.',
  },
  {
    title: 'Sala de Aula',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor.',
  },
];

export default function Home() {
  const navigation = useAppNavigation();

  return (
    <S.Container>
      <ScrollView
        showsVerticalScrollIndicator={false}
        stickyHeaderIndices={[2]} 
      >
        <Logo />

        <S.HelloText>Olá, Allan</S.HelloText>

        <S.StickyHeaderContainer>
          <S.Header>
            <S.GalleryTitle>Galeria</S.GalleryTitle>
            <Ionicons
              name="search-outline"
              size={28}
              color="black"
            />
          </S.Header>
        </S.StickyHeaderContainer>

        <S.GalleryItemsContainer>
          {data.map((item, index) => (
            <GalleryCard
              key={index}
              title={item.title}
              description={item.description}
              onClick = {() => navigation.navigate('MetricsPage')}
            />
          ))}
        </S.GalleryItemsContainer>

      </ScrollView>
      <BottomBar/>
    </S.Container>
  );
}