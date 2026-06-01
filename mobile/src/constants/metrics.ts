import { MetricType } from '../types/metrics';

export const metrics: {
  metric: MetricType;
  icon: string;
}[] = [
  { metric: "Público", icon: "people-outline" },
  { metric: "Ruído", icon: "volume-medium-outline" },
  { metric: "Brilho", icon: "sunny-outline" },
  { metric: "Perguntas", icon: "help-circle-outline" },
  { metric: "Tempo", icon: "hourglass-outline" },
];