import * as S from './styles';

type Props = {
  title: string;
  description: string;
};

export function GalleryCard({ title, description }: Props) {
  return (
    <S.Container>
      <S.CardImage />

      <S.TextContainer>
        <S.Title>{title}</S.Title>
        <S.Description>{description}</S.Description>
      </S.TextContainer>
    </S.Container>
  );
}