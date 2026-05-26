import * as S from './styles'

type Props = {
    name: string,
}

export default function Button({ name }: Props){
    return(
        <S.Container>
            <S.ButtonText>
                {name}
            </S.ButtonText>
        </S.Container>
    );
}